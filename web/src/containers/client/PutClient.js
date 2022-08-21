import {
    DatePicker,
    Form,
    Input,
    Button,
} from 'antd';

import React, { useState, useEffect } from 'react';
import { useHistory } from 'react-router-dom';

import './styles.css'
import api from '../../services/api';
import moment from "moment";

import PopUpSucess from '../popup/PopUpSucess';

export default function PutClient(handleKeyObj) {
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
            await api.put('api/Cliente/' + handleKeyObj.handleKey, data);

            <PopUpSucess title="Cliente" description="Cliente atualizado com sucesso!"/>
           
            history.push('/');
            window.location.reload(false);
        } catch(err){
            console.log('Erro ao atualizar as informações do cliente, tente novamente.');
        }
    }

    const fetchData = async () => {
        try {
            const res = await api.get('api/Cliente/' + handleKeyObj.handleKey);
            
            setNome(res.data.nome);
            setCpf(res.data.cpf);
        } catch (err) {
        console.log(err);
        }
    }
    useEffect(() => {
        fetchData();
    },[]);
    
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
                <DatePicker defaultValue={moment()} value={dataNascimento} onChange={handleChange} format={'DD/MM/YYYY'}/>
            </Form.Item>

            <Form.Item label="CPF">
                <Input style={{ width: 150}} maxLength={11} value={cpf} onChange={e => setCpf(e.target.value)}/>
            </Form.Item>

            <Button style={{ width: 200, }} onClick={handleNewClient} className='btn-post-client' type="primary" >Atualizar</Button>
        </Form>
    );
};