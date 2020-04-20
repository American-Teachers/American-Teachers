import React from 'react';
import { NavLink as RouterLink } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import Typography from '@material-ui/core/Typography';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Link from '@material-ui/core/Link';
import Button from '@material-ui/core/Button';
import useScrollTrigger from '@material-ui/core/useScrollTrigger';

import IconButton from '@material-ui/core/IconButton';
import userIcon from '../../public/header-icon-user.svg';
import hamburger from '../../public/header-icon-hamburger.svg'

import { makeStyles } from '@material-ui/core/styles';

const headerData = {
  navbarVisiblePages: ['/', '/why-us'],
  buttons: [
    {
      text: "Why Us",
      link: '/why-us'
    }
  ]
}

const useStyles = makeStyles((theme) => ({
  headerOffset: {height: theme.spacing(12)},
  appbar: {
    backgroundColor: 'white',
    color: 'black',
    paddingTop: theme.spacing(2),
    height: theme.spacing(12)
  },
  toolbar:{
    padding: `0 ${theme.spacing(4)}px ${theme.spacing(1)}px`,
    justifyContent: 'space-between'
  },
  title: {
    paddingTop: theme.spacing(0.25),
    '& p': {
      fontFamily: 'Montserrat',
      fontWeight: '600',
      fontSize: '18px'
    }
  },
  buttonCollection: {
    padding: `${theme.spacing(1)}px ${theme.spacing(4.5)}px 0 0`
  },
  navButton: {
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
        width: '75%',
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
  },

  hamburgerContainer: {
    backgroundColor: 'transparent',
    width: theme.spacing(3.75),
    height: theme.spacing(2.75),
    margin: `0 ${theme.spacing(2.25)}px 0 ${theme.spacing(1.5)}px`,
    padding: 0,

    '& img': {
      height: '100%',
      width: '100%',
      position: 'relative',
    }
  },

  userIconContainer: {
    backgroundColor: 'transparent',
    margin: `0 ${theme.spacing(1)}px 0 ${theme.spacing(2)}px`,
    height: theme.spacing(3.75),
    width: theme.spacing(3.75),
    padding: 0,

    '& img': {
      height: '100%',
      width: '100%',
      position: 'relative',
      top: '16%'
    }
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

function NavbarButtons() {
  const classes = useStyles();
  return (
    <>
      {headerData.buttons.map(buttonData => (
        <Button
          className={classes.navButton}
          component={RouterLink}
          to={buttonData.link}
          key={buttonData.text}
        >
          {buttonData.text}
          <div className='activeBottom' ></div>
        </Button>
      ))}
    </>
  )
}

function SignInButonGroup() {
  const classes = useStyles();

  return (
    <>
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
    </>
  )
}

function Hamburger() {
  const classes = useStyles();
  return (
    <IconButton className={classes.hamburgerContainer}>
      <img src={hamburger} />
    </IconButton>
  )
}

function UserIcon() {
  const classes = useStyles();
  return (
    <IconButton className={classes.userIconContainer}>
      <img src={userIcon} />
    </IconButton>
  )
}

function ElevationScroll({children}) {
  const trigger = useScrollTrigger({
    disableHysteresis: true,
    threshold: 0,
    target: window,
  });

  return React.cloneElement(children, {
    elevation: trigger ? 3 : 0,
  })
}

export default function Header({ signedIn, locationPathname }) {
  const classes = useStyles();

  return (
    <>
      <ElevationScroll >
        <AppBar position='fixed' elevation={0} className={classes.appbar}>
          <Toolbar className={classes.toolbar}>

            <Box display='flex'>
            
              { signedIn ? <Hamburger /> : <></> }

              <Logo />

            </Box>

            <Box className={classes.buttonCollection} >

              { headerData.navbarVisiblePages.includes(locationPathname) ? <NavbarButtons/> : <></> }

              { signedIn ? <UserIcon /> : <SignInButonGroup/> }

            </Box>

          </Toolbar>
        </AppBar>
      </ElevationScroll>
      <div className={classes.headerOffset}/>
    </>
  )
}