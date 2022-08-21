import { Space, Table, Button } from 'antd';
import React, { useState, useEffect } from 'react';

import './styles.css'

import api from '../../services/api';
import PopUpSucess from '../popup/PopUpSucess';
import PopUpError from '../popup/PopUpError';

async function DeleteMovieRental(key){
  try {
      await api.delete('api/Locacao/'+ key);
      <PopUpSucess title="Locação" description="Locação deletada com sucesso!"/>

      window.location.reload(false);
  } catch(err){
    <PopUpError title="Cliente" description='Erro ao deletar uma locação, tente novamente.'/>
  }
}

const { Column } = Table;
export default function GetMovieRental({addFunc}) {
  const [rentalMovies, setRentalMovies] = useState([]);
  const fetchData = async () => {
    try {
      const res = await api.get('api/Locacao');
      setRentalMovies(res.data);
    } catch (err) {
      <PopUpError title="Cliente" description={err}/>
    }
  }
  useEffect(() => {
    fetchData();
  },[]);

  return (
    <div>
      <Button onClick={(e)=> addFunc("postMovieRental", "child")} className='get-movie-rental-button' type="primary">Alugar filme</Button>

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
          render={(e, record) => (
            <Space size="middle">
              <Button onClick={()=> console.log(record.key)}>Alterar</Button>
              <Button onClick={()=> DeleteMovieRental(record.key)}>Excluir</Button>
            </Space>
          )}
        />
      </Table>
    </div>
  )
};