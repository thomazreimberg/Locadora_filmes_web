import { Space, Table, Button } from 'antd';
import React, { useState, useEffect } from 'react';
import './styles.css'

import api from '../../services/api';
import PopUpSucess from '../popup/PopUpSucess';
import PopUpError from '../popup/PopUpError';

async function DeleteClient(key){
  try {
      await api.delete('api/Cliente/'+ key);
      <PopUpSucess title="Cliente" description="Cliente deletado com sucesso"/>

      window.location.reload(false);
  } catch(err){
      <PopUpError title="Cliente" description='Erro ao deletar um cliente, tente novamente.'/>
  }
}

const { Column } = Table;
export default function GetClient({addFunc}) {

  const [clients, setClients] = useState([]);
  const fetchData = async () => {
    try {
      const res = await api.get('api/Cliente');
      setClients(res.data);
    } catch (err) {
      <PopUpError title="Cliente" description={err}/>
    }
  }
  useEffect(() => {
    fetchData();
  },[]);
   
  return (
    <div>
      <Button name="postClient" onClick={(e)=> addFunc("postClient", "child")} className='get-client-button' type="primary" >Cadastrar cliente</Button>

      <Table dataSource={clients}>
        <Column title="Nome" dataIndex="nome" key="nome" />
        <Column title="CPF" dataIndex="cpf" key="cpf" />
        <Column title="Data de nascimento" dataIndex="dataNascimento" key="dataNascimento" />
        <Column
          title="Action"
          key="action"
          dataIndex="key"
          render={(_, record) => (
            <Space size="middle">
              <Button onClick={()=> addFunc("updateClient", "child", record.key)}>Alterar</Button>
              <Button onClick={()=> DeleteClient(record.key)}>Excluir</Button>
            </Space>
          )}
        />
      </Table>
    </div>
  )
};