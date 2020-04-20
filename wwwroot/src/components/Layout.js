import React from 'react';
import { useLocation } from 'react-router-dom';

import CssBaseline from '@material-ui/core/CssBaseline';
import Container from '@material-ui/core/Container';

import { makeStyles } from '@material-ui/core/styles';

import Header from './Header';
import Footer from './Footer';

// const useStyles = makeStyles((theme) => ({
//   root:{}
// }))

const footerVisiblePages = ['/', '/why-us'];
const signedIn = false;

export default function Layout({footerHidden, children}) {
  // const classes = useStyles();
  let location = useLocation();
  
  return (
    <Container 
      // className={classes.root}
      maxWidth = 'xl'
      disableGutters
    >
      <CssBaseline/>

      <Header signedIn={signedIn} locationPathname={location.pathname}/>

      {children}
      
      {footerVisiblePages.includes(location.pathname) ? <Footer /> : <></>}

    </Container>
  )
}