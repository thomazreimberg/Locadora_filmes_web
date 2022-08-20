import {
  DesktopOutlined,
  PieChartOutlined,
  ShoppingOutlined,
  UserOutlined,
} from '@ant-design/icons';
import { Breadcrumb, Layout, Menu } from 'antd';

import './styles.css';
import React, { useState } from 'react';
import GetClient from '../../containers/client/GetClient'
import GetMovie from '../../containers/movie/GetMovie'
import GetMovieRental from '../../containers/movieRental/GetMovieRental'
import PostClient from '../../containers/client/PostClient';
import PostMovie from '../../containers/movie/PostMovie';
import PostMovieRental from '../../containers/movieRental/PostMovieRental';

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
  getItem('Home', 'homeChild', <PieChartOutlined />),
  getItem('Alugar filmes', 'movieRental', <ShoppingOutlined />),
  getItem('Filme', 'movie', <DesktopOutlined />),
  getItem('Cliente', 'client', <UserOutlined />),
];

export default function App() {
  const [collapsed, setCollapsed] = useState(false);
  const initial = {
    homeChild: false,
    client: false,
    movie: false,
    movieRental: false,
    postClient: false,
    postMovie: false,
    postMovieRental: false,
  }
  const [menuControl, setmenuControl] = useState(initial)

  const handleControl = (val, option) => {
    if(option === "parent"){
      setmenuControl({ ...initial, [val.key]: !initial[val.key] });
    } else {
      setmenuControl({ ...initial, [val]: !initial[val] });
    }
  }

  return (
    <Layout
      style={{
        minHeight: '100vh',
      }}
    >
      <Sider collapsible collapsed={collapsed} onCollapse={(value) => setCollapsed(value)}>
        <div className="logo" />
        <Menu className="site-layout-menu" theme="dark" defaultSelectedKeys={['1']} mode="inline" items={items} onClick={(e)=> handleControl(e, "parent")} />
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
            <Breadcrumb.Item>Locadora React</Breadcrumb.Item>
          </Breadcrumb>
          <div className="site-layout-background">
            {
              menuControl.client ?
                <GetClient  addFunc={handleControl} /> :
                  menuControl.postClient ?
                    <PostClient /> :
                      menuControl.movieRental ?
                        <GetMovieRental addFunc={handleControl} /> : 
                          menuControl.postMovieRental ?
                            <PostMovieRental /> : 
                              menuControl.movie ?
                                <GetMovie addFunc={handleControl} />:
                                  menuControl.postMovie ?
                                    <PostMovie />:
                                      <p>Home</p>
              }
          </div>
        </Content>
      </Layout>
    </Layout>
  );
};