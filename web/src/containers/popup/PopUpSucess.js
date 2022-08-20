import { CheckCircleOutlined } from '@ant-design/icons';
import { notification } from 'antd';
import React from 'react';

export default function PopUpSucess(title, description) {
  notification.success({
    message: title,
    description: description,
    icon: (
      <CheckCircleOutlined
        style={{
          color: '#00FF00',
        }}
      />
    ),
  });
};