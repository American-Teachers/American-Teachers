import React from 'react';
import { Link as RouterLink } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import Container from '@material-ui/core/Container';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';

import Layout from '../components/Layout';
import { makeStyles } from '@material-ui/core/styles';

import toolsIcon from '../img/landing/tools-icon.svg';
import accessIcon from '../img/landing/access-icon.svg';
import laptopIcon from '../img/landing/laptop-icon.svg';
import triangleChild from '../img/landing/triangle-child.jpg';
import squareChild from '../img/landing/square-child.jpg';
import circleChild from '../img/landing/circle-child.jpg';

const landing1Data = {
  title: "Learning can't stop.",
  copy: "Dedicated to continuing to educate our future and stay connected, no matter what."
};

const landing2Data = {
  title: "Education wherever you are.",
  icons: [
    {
      img: toolsIcon,
      title: 'Tools for Teachers',
      copy: 'Assign work, grade, post videos or agendas all in one platform.'
    },
    {
      img: accessIcon,
      title: 'Parent Access & Monitoring',
      copy: "Monitor your child's school work, grades, and more."
    },
    {
      img: laptopIcon,
      title: 'Easy Learning for Students',
      copy: "Easy to access resources and tools for learning, studying and connecting."
    }
  ]
};

const useStyles = makeStyles((theme) => ({
  root: {},
  landing1root: {
    height: '86vh',
    paddingTop: theme.spacing(33),
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
    marginTop: theme.spacing(3),
    justifyContent: 'flex-end',
  
    '& a': {
      width: theme.spacing(20.25),
      height: theme.spacing(5.25),
      boxShadow: 'none',

      '&:last-child': {marginLeft: theme.spacing(2)},
      '& p': {
        fontSize: '16px', 
        fontWeight: 700,
        letterSpacing: '0.05em'
      }
    }
  },
  landing1TriangleChild: {
    width: '262px',
    height: '411.28px',
    position: 'relative',
    top: -theme.spacing(56),
    left: theme.spacing(53),
    clipPath: 'polygon(50% 22%, 3% 76%, 97% 76%)'
  },
  landing1CircleChild: {
    width: '233px',
    height: '350px',
    position: 'relative',
    top: -theme.spacing(67),
    left: theme.spacing(52),
    clipPath: 'circle(116px at 50% 66%)'
  },
  landing1SquareChild: {
    width: '345px',
    height: '233.09px',
    position: 'relative',
    top: -theme.spacing(33.5),
    left: theme.spacing(2.5),
    clipPath: 'polygon(11% 0%, 11% 100%, 76% 100%, 76% 0%)'
  },

  
  landing2root: {
    height: '86vh',
    paddingTop: theme.spacing(6)
  },
  landing2Container: {textAlign: 'center'},
  landing2Title: {
    fontSize: '32px',
    fontWeight: 600,
    marginBottom: theme.spacing(9)
  },
  landing2ItemBox: {
    width: theme.spacing(48),
    margin: 0,

    '& h3': {
      fontSize: '24px',
      fontWeight: 600,
      marginBottom: theme.spacing(1)
    },
    '& p': {
      fontSize: '18px',
      lineHeight: '25px'
    },
    '&:last-child > div': {
      width: theme.spacing(16),
      position: 'relative',
      top: -theme.spacing(1)
    }
  },
  landing2ImgContainer: {
    width: theme.spacing(15),
    height: theme.spacing(15),
    margin: `0 auto ${theme.spacing(2.5)}px`
  },
  test: {backgroundColor: 'red'}
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
          {landing1Data.title}
        </Typography>

        <Typography className={classes.landing1CopyBody}>
          {landing1Data.copy}
        </Typography>

        <Box 
          className={classes.landing1ButtonCollection} 
          display='flex'
          justifyContent="flex-end"
        >
          <Button
            variant='outlined'
            color='primary'
            component={RouterLink}
            to='/why-us'
          >
            <Typography>
              Learn more
            </Typography>
          </Button>

          <Button
            variant='contained'
            color='primary'
            component={RouterLink}
            to='/signin'
          >
            <Typography>
              Get Started
            </Typography>
          </Button>
        </Box>
      </Container>

      <img src={triangleChild} alt='child reading' className={classes.landing1TriangleChild}/>
      <img src={circleChild} alt='child at computer' className={classes.landing1CircleChild}/>
      <img src={squareChild} alt='child reading tablet' className={classes.landing1SquareChild}/>

    </Container>
  )
}



export function Landing2() {
  const classes = useStyles();

  return (
    <Container
      className={classes.landing2root}
      maxWidth='lg'
    >
      <Container className={classes.landing2Container}>
        <Typography className={classes.landing2Title} component='h2'>
          {landing2Data.title}
        </Typography>

        <Box
          display='flex'
          justifyContent='center'
        >
          {landing2Data.icons.map((i, index) => (
            <Container key={index} className={classes.landing2ItemBox}>
              <Box className={classes.landing2ImgContainer}>
                <img src={i.img}/>
              </Box>

              <Typography component='h3'>
                {i.title}
              </Typography>

              <Typography>
                {i.copy}
              </Typography>
            </Container>
          ))}
        </Box>
      </Container>
    </Container>
  )
}

export default function Landing() {
  return (
    <Layout>
      <Landing1/>
      <Landing2/>
    </Layout>
  )
}