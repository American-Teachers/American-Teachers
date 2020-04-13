import React from 'react';
import { NavLink as RouterLink, useLocation } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import Typography from '@material-ui/core/Typography';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Link from '@material-ui/core/Link';
import Button from '@material-ui/core/Button';
import Collapse from '@material-ui/core/Collapse';

import { makeStyles } from '@material-ui/core/styles';

const headerData = {
  signedIn: false
}

const useStyles = makeStyles((theme) => ({
  appbar: {
    backgroundColor: 'white',
    color: 'black',
    paddingTop: theme.spacing(2)
  },
  toolbar:{
    padding: `0 ${theme.spacing(4)}px`,
    justifyContent: 'space-between'
  },
  title: {
    '& p': {
      fontFamily: 'Montserrat',
      fontWeight: '600',
      fontSize: '18px'
    }
  },
  buttonCollection: {paddingRight: theme.spacing(4)},
  buttonWhy: {
    textTransform: 'none',
    marginRight: theme.spacing(4),
    '& span.MuiButton-label': {
      fontSize: '16px',
      fontWeight: '600'
    },
    '& .activeBottom': {display: 'hidden'},

    '&.active': {
      '& span.MuiButton-label': {
        fontWeight: '800',
        color: theme.palette.primary.main,
      },
      '& .activeBottom': {
        width: theme.spacing(7),
        borderRadius: '15%',
        height: '3px',
        position: 'absolute',
        top: theme.spacing(5.8),
        backgroundColor: theme.palette.primary.main
      }
    }
  },
  buttonSign: {
    width: theme.spacing(14),
    height: theme.spacing(5),
    marginLeft: theme.spacing(2),
    boxShadow: 'none'
  },
  buttonSignLabel: {
    fontSize: '16px',
    fontWeight: '700'
  }
}));

export function Logo() {
  const classes = useStyles();
  
  return (
    <Link 
      href='/'  
      color='primary' 
      underline='none'
      className={classes.title}
    >
      <Typography  >
        American Teachers
      </Typography>
    </Link>
  )
}

function HeaderButtons({location, signedIn}) {
  const classes = useStyles();

  if (location.pathname==='/signin'||location.pathname==='/signup') {
    return (<></>);
  } else if (signedIn) {
    return (<></>);
  } else {
    return (
      <Box className={classes.buttonCollection} >
        <Button
          className={classes.buttonWhy}
          component={RouterLink}
          to='/why-us'
        >
          Why Us
          <div className='activeBottom' ></div>
        </Button>

        <Button
          classes={{
            root: classes.buttonSign,
            label: classes.buttonSignLabel
          }}
          color='primary'
          variant='outlined'
          component={RouterLink}
          to='/signin'
        >
          Sign In
        </Button>

        <Button 
          classes={{
            root: classes.buttonSign,
            label: classes.buttonSignLabel
          }}
          color='primary'
          variant='contained'
          component={RouterLink}
          to='/signup'
        >
          Sign Up
        </Button>
      </Box>
    );
  }
}

export default function Header() {
  const classes = useStyles();
  
  let location = useLocation();
  console.log(location)

  return (
    <AppBar position='static' elevation={0} className={classes.appbar}>
      <Toolbar className={classes.toolbar}>

        <Logo />

        <HeaderButtons 
          location={location}
          signedIn={headerData.signedIn}
        />

      </Toolbar>
    </AppBar>
  )
}