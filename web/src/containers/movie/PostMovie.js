import {
    Form,
    Input,
    Button,
    InputNumber,
    Checkbox
} from 'antd';

import React, { useState } from 'react';

import './styles.css'
import api from '../../services/api';

import PopUpSucess from '../popup/PopUpSucess';

export default function PostMovie() {
    const [titulo, setTitulo] = useState();
    const [classificacaoIndicada, setClassificacaoIndicada] = useState();
    const [lancamento, setLancamento] = useState();

    async function handleNewClient(e){
        e.preventDefault();

        const data = {
            titulo,
            classificacaoIndicada,
            lancamento,
        };

        try {
            await api.post('api/Filme', data);

            <PopUpSucess title="Filme" description="Filme cadastrado com sucesso"/>
           
            document.cookie = 'appname=movie';

            window.location.reload(false);
        } catch(err){
            console.log('Erro ao cadastrar um filme, tente novamente.');
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
                <Input  style={{ width: 450}} maxLength={200} value={titulo} onChange={e => setTitulo(e.target.value)}/>
            </Form.Item>

            <Form.Item label="Classificação indicada">
                <InputNumber  style={{ width: 450}} maxLength={200} value={titulo} onChange={e => setClassificacaoIndicada(e.target.value)}/>
            </Form.Item>
            
            <Form.Item label="Lançamento">
                <Checkbox style={{ width: 150}} value={lancamento} onChange={e => setLancamento(e.target.value)}/>
            </Form.Item>

            <Button style={{ width: 200, }} onClick={handleNewClient} className='btn-post-movie' type="primary" >Enviar</Button>
        </Form>
    );
};