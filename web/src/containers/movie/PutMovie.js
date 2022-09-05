import {
    Form,
    Input,
    Button,
    InputNumber,
    Checkbox
} from 'antd';

import React, { useState, useEffect } from 'react';

import './styles.css'
import api from '../../services/api';

import PopUpSucess from '../popup/PopUpSucess';
import PopUpError from '../popup/PopUpError';

export default function PutMovie(handleKeyObj) {
    const [titulo, setTitulo] = useState("");
    const [classificacaoIndicada, setClassificacaoIndicada] = useState(1);
    const [lancamento, setLancamento] = useState(false);

    async function handlePutMovie(e){
        e.preventDefault();

        const data = {
            titulo,
            classificacaoIndicada,
            lancamento,
        };

        try {
            await api.put('api/Filme/'+ handleKeyObj.handleKey, data);

            <PopUpSucess title="Filme" description="Filme atualizado com sucesso!"/>

            window.location.reload(false);
        } catch(err){
            <PopUpError title="Cliente" description="Erro ao atualizar um filme, tente novamente."/>
        }
    }

    const fetchData = async () => {
        try {
            const res = await api.get('api/Filme/' + handleKeyObj.handleKey);
            
            setTitulo(res.data.titulo);
            setClassificacaoIndicada(res.data.classificacaoIndicada);
            setLancamento(res.data.lancamento);
            console.log(res.data.lancamento);
        } catch (err) {
            <PopUpError title="Cliente" description={err}/>
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
                <Input  style={{ width: 450}} maxLength={200} value={titulo} onChange={e => setTitulo(e.target.value)}/>
            </Form.Item>

            <Form.Item label="Classificação indicada">
                <InputNumber defaultValue={1} min={1} max={18} value={classificacaoIndicada} onChange={e => setClassificacaoIndicada(e)}/>
            </Form.Item>
            
            <Form.Item label="Lançamento">
                <Checkbox checked={lancamento} style={{ width: 150}} onClick={e => setLancamento(e.target.checked)}/>
            </Form.Item>

            <Button style={{ width: 200, }} onClick={handlePutMovie} className='btn-post-movie' type="primary" >Atualizar</Button>
        </Form>
    );
};