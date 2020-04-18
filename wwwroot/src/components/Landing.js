import React from 'react';
import { Link as RouterLink } from 'react-router-dom';
import { Button, Typography, Container, Box, Grid, makeStyles }from '@material-ui/core';

import Layout from './Layout';

import toolsIcon from '../../public/landing-icon-tools.svg';
import accessIcon from '../../public/landing-icon-access.svg';
import laptopIcon from '../../public/landing-icon-laptop.svg';
import triangleChild from '../../public/landing-trianglechild.jpg';
import squareChild from '../../public/landing-squarechild.jpg';
import circleChild from '../../public/landing-circlechild.jpg';

const landingHomeData = {
  title: "Learning can't stop.",
  copy: "Dedicated to continuing to educate our future and stay connected, no matter what."
};

const featureCollectionData = {
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
  landingHomeRoot: {
    minHeight: '86vh',
    height: 'fit-content',
    paddingTop: theme.spacing(33),
    paddingLeft: theme.spacing(1)
  },
  landingHomeCopyContainer: {
    width: theme.spacing(55),
    margin: 0,
  },
  landingHomeCopyTitle: {
    fontSize: '40px',
    lineHeight: '54px',
    fontWeight: 600,
    color: theme.palette.primary.main,
  },
  landingHomeCopyBody: {fontSize: '18px'},

  landingHomeButtonCollection: {
    marginTop: theme.spacing(3),
    justifyContent: 'flex-end',
  
    '& a': {
      width: theme.spacing(20.25),
      height: theme.spacing(5.25),
      boxShadow: 'none',

      '&:last-child': {marginLeft: theme.spacing(2)},
    }
  },
  landingHomeButtonLabel: {
    fontSize: '16px', 
    fontWeight: 700,
    letterSpacing: '0.05em'
  },

  landingHomeTriangleChild: {
    width: '262px',
    height: '411.28px',
    position: 'relative',
    top: -theme.spacing(56),
    left: theme.spacing(53),
    clipPath: 'polygon(50% 22%, 3% 76%, 97% 76%)',
  },
  landingHomeCircleChild: {
    width: '233px',
    height: '350px',
    position: 'relative',
    top: -theme.spacing(67),
    left: theme.spacing(52),
    clipPath: 'circle(116px at 50% 66%)',
    filter: 'brightness(140%) contrast(68%) saturate(128%)'
  },
  landingHomeSquareChild: {
    width: '345px',
    height: '233.09px',
    position: 'relative',
    top: -theme.spacing(33.5),
    left: theme.spacing(2.5),
    clipPath: 'polygon(11% 0%, 11% 100%, 76% 100%, 76% 0%)',
    filter: 'brightness(135%) contrast(90%) saturate(90%) opacity(87%)'
  },

  
  featureCollectionRoot: {
    height: '86vh',
    paddingTop: theme.spacing(6)
  },
  featureCollectionContainer: {
    textAlign: 'center',
    [theme.breakpoints.down('lg')]: {
      padding: '0 10%'
    }
  },
  featureCollectionTitle: {
    fontSize: '32px',
    fontWeight: 600,
    marginBottom: theme.spacing(9)
  },
  featureCollectionItemBox: {
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
  featureCollectionImgContainer: {
    width: theme.spacing(15),
    height: theme.spacing(15),
    margin: `0 auto ${theme.spacing(2.5)}px`
  },
  test: {backgroundColor: 'red'}
}))


function LandingHome() {
  const classes = useStyles();

  return (
    <Container
      className={classes.landingHomeRoot}
      maxWidth='md'
    >
      <Container className={classes.landingHomeCopyContainer}>
        <Typography className={classes.landingHomeCopyTitle} component='h1'>
          {landingHomeData.title}
        </Typography>

        <Typography className={classes.landingHomeCopyBody}>
          {landingHomeData.copy}
        </Typography>

        <Box 
          className={classes.landingHomeButtonCollection} 
          display='flex'
          justifyContent="flex-end"
        >
          <Button
            variant='outlined'
            color='primary'
            component={RouterLink}
            to='/why-us'
            classes={{label: classes.landingHomeButtonLabel}}
          >
            Learn more
          </Button>

          <Button
            variant='contained'
            color='primary'
            component={RouterLink}
            to='/signin'
            classes={{label: classes.landingHomeButtonLabel}}
          >
            Get Started
          </Button>
        </Box>
      </Container>

      <img src={triangleChild} alt='child reading' className={classes.landingHomeTriangleChild}/>
      <img src={circleChild} alt='child at computer' className={classes.landingHomeCircleChild}/>
      <img src={squareChild} alt='child reading tablet' className={classes.landingHomeSquareChild}/>

    </Container>
  )
}

export function FeatureCollection() {
  const classes = useStyles();

  return (
    <Container
      className={classes.featureCollectionRoot}
      maxWidth='lg'
    >
      <Container className={classes.featureCollectionContainer}>
        <Typography className={classes.featureCollectionTitle} component='h2'>
          {featureCollectionData.title}
        </Typography>

        <Grid
          container
          justify='space-between'
          spacing={3}
        >
          {featureCollectionData.icons.map((i, index) => (
            <Grid 
              item
              key={index} 
              className={classes.featureCollectionItemBox}
              xs={12}
              sm={4}
            >
              <Box className={classes.featureCollectionImgContainer}>
                <img src={i.img} alt='Icon'/>
              </Box>

              <Typography component='h3'>
                {i.title}
              </Typography>

              <Typography>
                {i.copy}
              </Typography>
            </Grid>
          ))}
        </Grid>
      </Container>
    </Container>
  )
}

export default function Landing() {
  return (
    <Layout>
      <LandingHome/>
      <FeatureCollection/>
    </Layout>
  )
}