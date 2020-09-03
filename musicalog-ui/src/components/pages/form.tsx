import React, {useState} from 'react';
import {Row, Col, Typography, Input, Form, Button, 
Radio, Switch, Slider, Select, message} from 'antd';
import axios from 'axios';
import {useHistory} from 'react-router';

const {Title} = Typography;

const layout = {
  labelCol: { span: 8 },
  wrapperCol: { span: 16 },
};

const FormApp = () => {
  const [loading, setLoading] = useState(false);
  const history = useHistory();

  const handleSubmit = (values: any) => {
    setLoading(true);
    axios.post(`http://localhost:3000/albums`, 
      values
    )
    .then(res => {
      setLoading(false);
      message.success('Album Added Successfully!');
      history.push('/album');
    })
    .catch(error => {
      setLoading(false);
      message.error(error);
    })
  }

  return (
    <div>
        <Row gutter={[40, 0]}>
          <Col span={23}>
            <Title style={{textAlign: 'center'}} level={2}>
             Fill the Album Details
            </Title>
            </Col>
        </Row>
        <Row gutter={[40, 0]}>
        <Col span={18}>
          <Form {...layout} onFinish={handleSubmit}>
            <Form.Item name="name" label="Name"
            rules={[
              {
                required: true,
                message: 'Enter Album name',
              }
            ]}
            >
              <Input placeholder="Album Name" />
            </Form.Item>
            <Form.Item name="artist" label="Artist" 
            rules={[
              {
                required: true,
                message: 'Enter Artist Name',
              }
            ]}
            >
              <Input placeholder="Artist Name" />
            </Form.Item>
            <Form.Item name="type" label="Type" 
            rules={[
              {
                required: true,
                message: 'Enter Type of Album',
              }
            ]}
            >
              <Radio.Group>
                <Radio value="cd">CD</Radio>
                <Radio value="vinyl">Vinyl</Radio>
                <Radio value="others">Others</Radio>

              </Radio.Group>
            </Form.Item>
            <Form.Item name="stock" label="Stock" 
            rules={[
              {
                required: true,
                message: 'Enter Stock'
              }
            ]}
            >
              {/* <Select mode="multiple" placeholder="Please select you hobbies">
                <Select.Option value="Reading">Reading</Select.Option>
                <Select.Option value="Writing">Writing</Select.Option>
                <Select.Option value="Coding">Coding</Select.Option>
                <Select.Option value="Singing">Singing</Select.Option>
                <Select.Option value="Dancing">Dancing</Select.Option>
              </Select> */}
            {/* </Form.Item>
            <Form.Item name="review" label="Review"
            >
              <Slider />
            </Form.Item>
            <Form.Item name="notificaiton" label="Notificaiton" valuePropName="checked"
            > */}
              {/* <Switch /> */}
              <Input placeholder="Stock" />
            </Form.Item>
            <div style={{textAlign: "right"}}>
            <Button type="primary" loading={loading} htmlType="submit">
              Save
            </Button>{' '}
            <Button type="default" htmlType="button" onClick={() => history.push('/albums')}>
              Back
            </Button>
              </div>
          </Form>
          </Col>
        </Row>
    </div>
  );
}

export default FormApp;
