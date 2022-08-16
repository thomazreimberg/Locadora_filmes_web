import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';

import ptBR from 'antd/lib/locale/pt_BR';
import { ConfigProvider } from 'antd';

import 'antd/dist/antd.min.css';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <ConfigProvider locale={ptBR}>
      <App />
    </ConfigProvider>
  </React.StrictMode>
);
