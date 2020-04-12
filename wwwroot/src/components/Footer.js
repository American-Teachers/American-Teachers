import React from 'react';
import { Container, Grid, Typography, List, ListItem } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';

import { Logo } from '../components/Header';

const useStyles = makeStyles((theme) => ({
  rootFooter: {
    height: theme.spacing(60),
    backgroundColor: '#33476A',
    color: 'white',
    padding: `${theme.spacing(12)}px ${theme.spacing(11.5)}px 0 0`,
  },
  logoContainer: {textAlign: 'center', paddingLeft: theme.spacing(2)},
  listsContainer: {paddingLeft: theme.spacing(8)},
  listTitle: {fontWeight: 'bold'},

  linkList: {
    '& li': {
      padding: `${theme.spacing(0.3)}px 0`,
      '& div': {margin: 0},
      '& a': {
        fontSize: '12px',
        color: 'white',
        textDecoration: 'none'
      }
    }
  }
}))

function ListWithTitle({title, children}) {
  const classes = useStyles();
  return (
    <>
      <Typography className={classes.listTitle}>
        {title}
      </Typography>
      
      <List className={classes.linkList}>
      {children}
      </List>
    </>
  )
}

function ListText({text, link}) {
  
  return (
    <ListItem disableGutters>
      <Typography>
        <a href={link}>{text}</a>
        {/* <Link to={link}>{text}</Link> */}
      </Typography>
    </ListItem>
  )
}

export default function Footer() {
  const classes = useStyles();

  return (
    <Container 
      className={classes.rootFooter}
      maxWidth='xl'
      // disableGutters
    >
      <Grid container >
        <Grid item xs={4} className={classes.logoContainer}>
          <Logo />
        </Grid>

        <Grid container item xs={8} className={classes.listsContainer} >
          <Grid item xs={3}>
            <ListWithTitle title='Quick Links'>
              <ListText 
                text='My Account'

              />
              <ListText 
                text='Create an Account'
                link='/signup'
              />
            </ListWithTitle>
          </Grid>

          <Grid item xs={3}>
            <ListWithTitle title='Company'>
              <ListText 
                text='About Us'
                link='/why-us'
              />
              <ListText 
                text='Press'

              />
              <ListText 
                text='Careers'

              />
            </ListWithTitle>
          </Grid>

          <Grid item xs={3}>
            <ListWithTitle title='Help'>
              <ListText 
                text='FAQ'

              />
              <ListText 
                text='Privacy Policy'

              />
              <ListText 
                text='Terms'

              />
            </ListWithTitle>
          </Grid>

          <Grid item xs={3}>
            <ListWithTitle title='Connect With Us'>
              <ListText
                text='contact@americanteachers.com'
                link='mailto:contact@americanteachers.com'
              />
            </ListWithTitle>
          </Grid>
        </Grid>


      </Grid>

    </Container>
  )
}