import React, {useEffect, useState} from 'react';
import {Table, Row, Col, Button,Card, Typography} from 'antd';
import {useHistory} from 'react-router';
import axios from 'axios';
import { EditOutlined, EllipsisOutlined,DeleteOutlined  } from '@ant-design/icons';
const {Title} = Typography;


const Album = () => {
  const history = useHistory();
  const [allData, setAllData] = useState([]);

  useEffect(() => {
    axios.get(`http://localhost:3000/albums`).then(res => {
      setAllData(res.data);
    });
  });

  const columns = [
    {
      title: 'name',
      dataIndex: 'name',
    },
    {
      title: 'artist',
      dataIndex: 'artist'
    },
    {
      title: 'type',
      dataIndex: 'type'
    },
    {
      title: 'stock',
      dataIndex: 'stock'
    },
  ];

  const data = [{
  }];

  allData.map((album: any) => {
    data.push({
     key: album.id,
     name: album.name,
     artist: album.artist,
     type: album.type,
     stock: album.stock,
   })
  // return data;
 });

  const handleClick = () => {
    history.push('/form')
  }

  return (
    <div className="site-card-wrapper">
        <Row gutter={[40, 0]}>
          <Col span={18}>
            <Title level={2}>
            Album List
            </Title>
            </Col>
          <Col span={6}>
          <Button onClick={handleClick} block>Add Album</Button>
          </Col>
        </Row>
        <Row gutter={[40, 0]}>
        {/* <Col span={24}>
        <Table columns={columns} dataSource={data} />
        </Col> */}

<Row gutter={[54, 54]}>

{data.map((value:any, index) => {
  //return <li key={index}>{value}</li>
  return  <Col span={8}>
    <Card title={value.name} bordered={true} extra={<a href={"/album/"+value.key}>Details</a>}
     actions={[
      <EditOutlined key="edit" />,
      <DeleteOutlined key="delete" />,
    ]}
    >
  </Card>
</Col>
})}
  
{/* <Col span={8}>
  <Card title="Card title" bordered={true}>
    Card content
  </Card>
</Col>
<Col span={8}>
  <Card title="Card title" bordered={true}>
    Card content
  </Card>
</Col>
<Col span={8}>
  <Card title="Card title" bordered={true}>
    Card content
  </Card>
  </Col>
  <Col span={8}>
  <Card title="Card title" bordered={true}>
    Card content
  </Card>
</Col>
<Col span={8}>
  <Card title="Card title" bordered={true}>
    Card content
  </Card>
</Col>
<Col span={8}>
  <Card title="Card title" bordered={true}>
    Card content
  </Card>
</Col> */}
</Row>
      </Row>
      
      
    </div>
  );
}

export default Album;