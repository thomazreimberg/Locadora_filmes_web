import { Space, Table, Button } from 'antd';
import React, { useState, useEffect } from 'react';

import './styles.css'

import api from '../../services/api';

const { Column } = Table;
export default function GetClient({addFunc}) {

  const [clients, setClients] = useState([]);
  const fetchData = async () => {
    try {
      const res = await api.get('api/Cliente');
      setClients(res.data);
    } catch (err) {
      console.log(err);
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
          render={() => (
            <Space size="middle">
              <a>Alterar</a>
              <a>Excluir</a>
            </Space>
          )}
        />
      </Table>
    </div>
  )
};