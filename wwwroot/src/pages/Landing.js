import React from 'react'

import { Box, Container, Typography, Button } from '@material-ui/core';

import Layout from '../components/Layout';
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((theme) => ({
  root: {},
  landing1root: {
    // backgroundColor: 'pink',
    height: '100vh',
    paddingTop: theme.spacing(34),
    paddingLeft: theme.spacing(1)
  },
  landing1CopyContainer: {
    width: theme.spacing(55),
    margin: 0,
  },
  landing1CopyTitle: {
    fontSize: '40px',
    lineHeight: '54px',
    fontWeight: 600,
    color: theme.palette.primary.main,
  },
  landing1CopyBody: {fontSize: '18px'},
  landing1ButtonCollection: {
    marginTop: theme.spacing(2.5),
    justifyContent: 'flex-end',
    '& button': {
      width: theme.spacing(20.25),
      boxShadow: 'none',
      '&:last-child': {marginLeft: theme.spacing(2)},
      '& p': {fontWeight: 700}
    }
  },

  landing2root: {
    height: '100vh',
  },
  test: {backgroundColor: 'red', height: '100vh'}
}))

function Landing1() {
  const classes = useStyles();
  return (
    <Container
      className={classes.landing1root}
      maxWidth='md'
    >
      <Container className={classes.landing1CopyContainer}>
        <Typography className={classes.landing1CopyTitle} component='h1'>
          Learning can't stop.
        </Typography>

        <Typography className={classes.landing1CopyBody}>
          Dedicated to continuing to educate our future and stay connected, no matter what.
        </Typography>

        <Box 
          className={classes.landing1ButtonCollection} 
          display='flex'
          justifyContent="flex-end"
        >
          <Button
            variant='outlined'
            color='primary'
          >
            <Typography>
              Learn more
            </Typography>
          </Button>

          <Button
            variant='contained'
            color='primary'
          >
            <Typography>
              Get Started
            </Typography>
          </Button>
        </Box>
      </Container>
      


    </Container>
  )
}

function Landing2() {
  return (
    <Container
      className={classes.landing2root}
      maxWidth='lg'
    >
      <div>Education</div>
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