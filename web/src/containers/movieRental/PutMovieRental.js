import {
    Form,
    Button,
    DatePicker,
    Select,
} from 'antd';

import React, { useState, useEffect } from 'react';

import './styles.css'
import api from '../../services/api';

import PopUpSucess from '../popup/PopUpSucess';
import PopUpError from '../popup/PopUpError';

const { Option } = Select;

export default function PutMovieRental(handleKeyObj) {
    const fetchData = async () => {
        try {
            const res = await api.get('api/Locacao/' + handleKeyObj.handleKey);
            
            setId_Cliente(res.data.id_Cliente);
            setId_Filme(res.data.id_Filme);
            
        } catch (err) {
            <PopUpError title="Locação" description={err}/>
        }
    }
    
    const [id_Cliente, setId_Cliente] = useState();
    const [id_Filme, setId_Filme] = useState();
    const [dataLocacao, setDataLocacao] = useState();
    const [dataDevolucao, setDataDevolucao] = useState();

    const handleChangeLocacao = (date, dateString) => {
        setDataLocacao(date);
    };

    const handleChangeDevolucao = (date, dateString) => {
        setDataDevolucao(date);
    };

    const [clients, setClients] = useState([]);
    const fetchDataClient = async () => {
        try {
        const res = await api.get('api/Cliente/Descricao');
        setClients(res.data);
        } catch (err) {
            <PopUpError title="Locação" description={err}/>
        }
    }

    const [movies, setMovies] = useState([]);
    const fetchDataMovie = async () => {
        try {
        const res = await api.get('api/Filme/Descricao');
        setMovies(res.data);
        } catch (err) {
            <PopUpError title="Locação" description={err}/>
        }
    }
    
    useEffect(() => {
        fetchData();
        fetchDataMovie();
        fetchDataClient();
    },[]);

    async function handlePutMovieRental(e){
        e.preventDefault();

        const data = {
            id_Cliente,
            id_Filme,
            dataLocacao,
            dataDevolucao,
        };

        try {
            await api.post('api/Locacao', data);

            <PopUpSucess title="Locação" description="Filme alugado com sucesso!"/>

            window.location.reload(false);
        } catch(err){
            <PopUpError title="Locação" description='Erro ao alugar um filme, tente novamente.'/>
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
            <Form.Item label="Filme">
                <Select style={{ width: 120, }} onChange={e => setId_Filme(e)}>
                    {movies.map(movie => (
                        <Option value={movie.key}>{movie.descricao}</Option>
                    ))}
                </Select>
            </Form.Item>

            <Form.Item label="Cliente">
                <Select style={{ width: 120, }} onChange={e => setId_Cliente(e)}>
                    {clients.map(client => (
                        <Option value={client.key}>{client.descricao}</Option>
                    ))}
                </Select>
            </Form.Item>

            <Form.Item label="Data de locação">
                <DatePicker name={dataLocacao} value={dataLocacao} onChange={handleChangeLocacao} format={'DD/MM/YYYY'}/>
            </Form.Item>

            <Form.Item label="Data de devolução">
                <DatePicker name={dataDevolucao} value={dataDevolucao} onChange={handleChangeDevolucao} format={'DD/MM/YYYY'}/>
            </Form.Item>

            <Button style={{ width: 200, }} onClick={handlePutMovieRental} className='btn-post-movie' type="primary">Enviar</Button>
        </Form>
    );
};