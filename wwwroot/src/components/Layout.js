import React from 'react';

import CssBaseline from '@material-ui/core/CssBaseline';
import Container from '@material-ui/core/Container';

import { makeStyles } from '@material-ui/core/styles';

import Header from './Header';
import Footer from './Footer';

// const useStyles = makeStyles((theme) => ({
//   root:{}
// }))

export default function Layout({footerHidden, children}) {
  // const classes = useStyles();

  return (
    <Container 
      // className={classes.root}
      maxWidth = 'xl'
      disableGutters
    >
      <CssBaseline/>

      <Header />

      {children}
      
      {footerHidden ? <></> : <Footer />}

    </Container>
  )
}