import { Typography } from '@material-ui/core';
import React from 'react';

export default function ColorTypography({color, ...props}) {
  return <Typography {...props} style={{color}}>{props.children}</Typography>
}
