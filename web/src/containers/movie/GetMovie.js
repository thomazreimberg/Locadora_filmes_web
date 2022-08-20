import { Space, Table, Button } from 'antd';
import React, { useState, useEffect } from 'react';

import './styles.css'

import api from '../../services/api';
import PopUpSucess from '../popup/PopUpSucess';

async function DeleteMovie(key){
  try {
      await api.delete('api/Filme/'+ key);
      <PopUpSucess title="Filme" description="Filme deletado com sucesso!"/>

      window.location.reload(false);
  } catch(err){
      console.log('Erro ao deletar um cliente, tente novamente.');
  }
}

const { Column } = Table;
export default function GetMovie({addFunc}) {
  const [movies, setMovies] = useState([]);
  const fetchData = async () => {
    try {
      const res = await api.get('api/Filme');
      setMovies(res.data);
    } catch (err) {
      console.log(err);
    }
  }
  useEffect(() => {
    fetchData();
  },[]);

  return (
    <div>
      <Button onClick={(e)=> addFunc("postMovie", "child")}  className='get-movie-button' type="primary">Cadastrar filme</Button>

      <Table dataSource={movies}>
        <Column title="Título" dataIndex="titulo" key="titulo" />
        <Column title="Classificação indicada" dataIndex="classificacaoIndicada" key="classificacaoIndicada" />
        <Column title="Lançamento" dataIndex="lancamento" key="lancamento" />
        <Column
          title="Action"
          key="action"
          render={(e, record) => (
            <Space size="middle">
              <Button onClick={()=> console.log(record.key)}>Alterar</Button>
              <Button onClick={()=> DeleteMovie(record.key)}>Excluir</Button>
            </Space>
          )}
        />
      </Table>
    </div>
  )
};