import {
  DesktopOutlined,
  PieChartOutlined,
  ShoppingOutlined,
  UserOutlined,
} from '@ant-design/icons';
import { Breadcrumb, Layout, Menu } from 'antd';

import './styles.css';
import React, { useState } from 'react';
import ClientSelect from '../../containers/client/ClientSelect'

const { Header, Content, Sider } = Layout;

function getItem(label, key, icon, children) {
  return {
    key,
    icon,
    children,
    label,
  };
}

const items = [
  getItem('Home', '1', <PieChartOutlined />),
  getItem('Alugar filmes', '2', <ShoppingOutlined />),
  getItem('Filme', '3', <DesktopOutlined />),
  getItem('Cliente', '4', <UserOutlined />),
];

export default function App() {
  const [collapsed, setCollapsed] = useState(false);
  return (
    <Layout
      style={{
        minHeight: '100vh',
      }}
    >
      <Sider collapsible collapsed={collapsed} onCollapse={(value) => setCollapsed(value)}>
        <div className="logo" />
        <Menu theme="dark" defaultSelectedKeys={['1']} mode="inline" items={items} />
      </Sider>
      <Layout className="site-layout">
        <Header className="site-layout-background" />
        <Content
          style={{
            margin: '0 16px',
          }}
        >
          <Breadcrumb
            style={{
              margin: '16px 0',
            }}
          >
            <Breadcrumb.Item>Nome da opção que selecionei atualmente.</Breadcrumb.Item>
          </Breadcrumb>
          <div className="site-layout-background">
            <ClientSelect />
          </div>
        </Content>
      </Layout>
    </Layout>
  );
};