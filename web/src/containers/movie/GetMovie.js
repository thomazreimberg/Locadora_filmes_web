import { Space, Table, Button } from 'antd';
import React, { useState, useEffect } from 'react';

import './styles.css'

import api from '../../services/api';

const { Column } = Table;
export default function GetMovie() {
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
      <Button className='get-movie-button' type="primary">Cadastrar filme</Button>

      <Table dataSource={movies}>
        <Column title="Título" dataIndex="titulo" key="titulo" />
        <Column title="Classificação indicada" dataIndex="classificacaoIndicada" key="classificacaoIndicada" />
        <Column title="Lançamento" dataIndex="lancamento" key="lancamento" />
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