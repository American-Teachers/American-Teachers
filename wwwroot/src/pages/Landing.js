import React from 'react'

import { Container } from '@material-ui/core';

import Layout from '../components/Layout';
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((theme) => ({
  root: {},
  test: {backgroundColor: 'red'}
}))

function Landing1() {
  const classes = useStyles();
  return (
    <Container
      className={classes.test}
      maxWidth='md'
    >
      <div>landing page 1</div>
    </Container>
  )
}

function Landing2() {
  return (
    <Container>

    </Container>
  )
}

export default function Landing() {
  return (
    <Layout>
      <Landing1/>
    </Layout>
  )
}