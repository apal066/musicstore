import React, {useEffect, useState} from 'react';
import {Table, Row, Col, Button,Card, Typography} from 'antd';
import {useHistory} from 'react-router';
import axios from 'axios';
import { EditOutlined, EllipsisOutlined, DeleteOutlined } from '@ant-design/icons';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link,
  useParams
} from "react-router-dom";
import { Descriptions } from 'antd';
const {Title} = Typography;


const AlbumDetail = () => {
  const history = useHistory();
  const [allData, setAllData] = useState([]);
  let { id } = useParams();
  useEffect(() => {
    axios.get(`http://localhost:3000/albums/`+id).then(res => {
      setAllData(res.data);
    });
  });

  

 
  return (
    <Descriptions title="User Info">
    <Descriptions.Item label="UserName">Zhou Maomao</Descriptions.Item>
    <Descriptions.Item label="Telephone">1810000000</Descriptions.Item>
    <Descriptions.Item label="Live">Hangzhou, Zhejiang</Descriptions.Item>
    <Descriptions.Item label="Remark">empty</Descriptions.Item>
    <Descriptions.Item label="Address">
      No. 18, Wantang Road, Xihu District, Hangzhou, Zhejiang, China
    </Descriptions.Item>
  </Descriptions>
  );
}

export default AlbumDetail;