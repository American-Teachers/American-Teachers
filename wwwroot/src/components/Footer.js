import React from 'react';
import { NavLink as RouterLink } from 'react-router-dom';

import { Box, Typography, AppBar, Toolbar, Link, Button } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((theme) => ({
  appbar: {
    backgroundColor: 'white',
    color: 'black'
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
  buttonCollection: {
    paddingRight: theme.spacing(5)
  },
  buttonWhy: {
    textTransform: 'none',
    marginRight: theme.spacing(5),
    '& p': {
      fontWeight: '600'
    },
    '& .activeBottom': {
      display: 'hidden',
    },

    '&.active': {
      borderBottom: '10px black',
      '& p': {
        fontWeight: '700',
        color: theme.palette.primary.main,
      },
      '& .activeBottom': {
        width: theme.spacing(6.5),
        height: '3px',
        position: 'absolute',
        top: theme.spacing(4.5),
        backgroundColor: theme.palette.primary.main
      }
    }
  },
  buttonSign: {
    boxShadow: 'none',
    marginLeft: theme.spacing(2),
    '& p': {
      fontWeight: '600'
    },
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

export default function Header() {
  const classes = useStyles();

  return (
    <AppBar position='static' elevation={0} className={classes.appbar}>
        <Toolbar className={classes.toolbar}>

          <Logo />

          <Box className={classes.buttonCollection} >
            <Button
              className={classes.buttonWhy}
              component={RouterLink}
              to='/why-us'
            >
              <Typography>
                Why Us
              </Typography>

              <div className='activeBottom' ></div>
            </Button>
      
            <Button
              className={classes.buttonSign}
              color='primary'
              variant='outlined'
            >
              <Typography>
                Sign In
              </Typography>
            </Button>

            <Button 
              className={classes.buttonSign}
              color='primary'
              variant='contained'
            >
              <Typography>
                Sign Up
              </Typography>
            </Button>
          </Box>

        </Toolbar>
      </AppBar>
  )
}