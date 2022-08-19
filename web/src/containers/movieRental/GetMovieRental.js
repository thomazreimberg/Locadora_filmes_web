import { Space, Table, Button } from 'antd';
import React, { useState, useEffect } from 'react';

import './styles.css'

import api from '../../services/api';

const { Column } = Table;
export default function GetMovie() {
  const [rentalMovies, setRentalMovies] = useState([]);
  const fetchData = async () => {
    try {
      const res = await api.get('api/Locacao');
      setRentalMovies(res.data);
    } catch (err) {
      console.log(err);
    }
  }
  useEffect(() => {
    fetchData();
  },[]);

  return (
    <div>
      <Button className='get-movie-rental-button' type="primary">Alugar um filme</Button>

      <Table dataSource={rentalMovies}>
        <Column title="Id locação" dataIndex="key" key="key" />
        <Column title="Filme" dataIndex="filme" key="filme" />
        <Column title="Cliente" dataIndex="cliente" key="cliente" />
        <Column title="Data locação" dataIndex="dataLocacao" key="dataLocacao" />
        <Column title="Previsão de devolução" dataIndex="dataPrevisaoDevolucao" key="dataPrevisaoDevolucao" />
        <Column title="Data de Devolução" dataIndex="dataDevolucao" key="dataDevolucao" />
        
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