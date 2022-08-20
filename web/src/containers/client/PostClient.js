import {
    DatePicker,
    Form,
    Input,
    Button,
} from 'antd';

import React, { useState } from 'react';
import { useHistory } from 'react-router-dom';

import './styles.css'
import api from '../../services/api';

import PopUpSucess from '../popup/PopUpSucess';

export default function PostClient() {
    const [nome, setNome] = useState();
    const [cpf, setCpf] = useState();
    const [dataNascimento, setDataNascimento] = useState();

    const history = useHistory();

    const handleChange = (date, dateString) => {
        setDataNascimento(date);
    };

    async function handleNewClient(e){
        e.preventDefault();

        const data = {
            nome,
            cpf,
            dataNascimento,
        };

        try {
            await api.post('api/Cliente', data);

            <PopUpSucess title="Cliente" description="Cliente cadastrado com sucesso"/>
           
            document.cookie = 'appname=client';

            history.push('/');
            window.location.reload(false);
        } catch(err){
            console.log('Erro ao cadastrar um cliente, tente novamente.');
        }
    }

    return (
        <Form
            color="black"
            labelCol={{
            span: 4,
            }}
            wrapperCol={{
            span: 14,
            }}
            layout="horizontal"
            initialValues={{
            size: "small",
            }}
        >
            <Form.Item label="Nome">
                <Input  style={{ width: 450}} maxLength={200} value={nome} onChange={e => setNome(e.target.value)}/>
            </Form.Item>

            <Form.Item label="Data de nascimento">
                <DatePicker name={dataNascimento} value={dataNascimento} onChange={handleChange} format={'DD/MM/YYYY'}/>
            </Form.Item>

            <Form.Item label="CPF">
                <Input style={{ width: 150}} maxLength={11} value={cpf} onChange={e => setCpf(e.target.value)}/>
            </Form.Item>

            <Button style={{ width: 200, }} onClick={handleNewClient} className='btn-post-client' type="primary" >Enviar</Button>
        </Form>
    );
};