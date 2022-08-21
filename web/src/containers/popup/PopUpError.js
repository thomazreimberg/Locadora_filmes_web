import { CloseCircleOutlined } from '@ant-design/icons';
import { notification } from 'antd';
import React from 'react';

export default function PopUpError(title, description) {
  notification.error({
    message: title,
    description: description,
    icon: (
      <CloseCircleOutlined
        style={{
          color: '#FF0000',
        }}
      />
    ),
  });
};