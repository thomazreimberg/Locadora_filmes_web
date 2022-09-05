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
import PopUpError from '../popup/PopUpError';

export default function PostMovie() {
    const [titulo, setTitulo] = useState("");
    const [classificacaoIndicada, setClassificacaoIndicada] = useState(1);
    const [lancamento, setLancamento] = useState(false);

    async function handleNewMovie(e){
        e.preventDefault();

        const data = {
            titulo,
            classificacaoIndicada,
            lancamento,
        };

        try {
            await api.post('api/Filme', data);

            <PopUpSucess title="Filme" description="Filme cadastrado com sucesso!"/>

            window.location.reload(false);
        } catch(err){
            <PopUpError title="Cliente" description="Erro ao cadastrar um filme, tente novamente."/>
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
                <InputNumber defaultValue={1} min={1} max={18} value={classificacaoIndicada} onChange={e => setClassificacaoIndicada(e)}/>
            </Form.Item>
            
            <Form.Item label="Lançamento">
                <Checkbox style={{ width: 150}} onClick={e => setLancamento(e.target.checked)}/>
            </Form.Item>

            <Button style={{ width: 200, }} onClick={handleNewMovie} className='btn-post-movie' type="primary" >Enviar</Button>
        </Form>
    );
};