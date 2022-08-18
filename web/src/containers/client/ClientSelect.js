import { Space, Table, Button } from 'antd';
import React, { useState, useEffect } from 'react';

import './styles.css'

import api from '../../services/api';

const { Column } = Table;
export default function ClientSelect() {
  const [clients, setClients] = useState([]);

  useEffect(() => {
    api.get('api/Cliente')
    .then(response => {
      setClients(response.data);
    })
  });

  return (
    <div>
      <Button className='clientSelect-button' type="primary">Cadastrar cliente</Button>

      <Table dataSource={clients}>
        <Column title="Nome" dataIndex="Nome" key="Nome" />
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