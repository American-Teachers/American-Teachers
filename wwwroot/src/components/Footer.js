import React from 'react';

import { Container, Grid, Typography, List, ListItem } from '@material-ui/core';

import { Logo } from '../components/Header';

import { makeStyles } from '@material-ui/core/styles';

import { Facebook, Twitter } from '@material-ui/icons';


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
  },
  iconCollection: {
    padding: 0,
    '& a': {
      color: '#FFFFFF',
      marginRight: theme.spacing(1.5),
      '&:last-child': {marginRight: 0}
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

  const footerData = [
    {
      title: 'Quick Links',
      links: [
        {
          text: 'My Account',
          link: ''
        },
        {
          text: 'Create an Account',
          link: '/signup'
        }
      ]
    },
    {
      title: 'Company',
      links: [
        {
          text: 'About Us',
          link: '/why-us'
        },
        {
          text: 'Press',
          link: ''
        },
        {
          text: 'Careers',
          link: ''
        }
      ]
    },
    {
      title: 'Help',
      links: [
        {
          text: 'FAQ',
          link: ''
        },
        {
          text: 'Privacy Policy',
          link: ''
        },
        {
          text: 'Terms',
          link: ''
        }
      ]
    },
    {
      title: 'Connect With Us',
      links: [
        {
          text: 'contact@americanteachers.com',
          link: 'mailto:contact@americanteachers.com'
        },
        {
          text: 'social',
          facebook: 'http://facebook.com',
          twitter: 'http://twitter.com'
        }
      ]
    }
  ]

  return (
    <Container 
      className={classes.rootFooter}
      maxWidth='xl'
    >
      <Grid container >
        <Grid item xs={4} className={classes.logoContainer}>
          <Logo />
        </Grid>

        <Grid container item xs={8} className={classes.listsContainer} >
          {
            footerData.map(section => (
                <Grid item xs={12/footerData.length}>
                  <ListWithTitle title={section.title}>
                    {
                      section.links.map(linkObj => {
                        return (
                          linkObj.text!=='social' ? 
                            <ListText 
                              text={linkObj.text}
                              link={linkObj.link || '#'}
                            />
                          :
                            <ListItem className={classes.iconCollection}>
                              <a href={linkObj.facebook} target='_blank' rel='noopener noreferrer'>
                                <Facebook/>
                              </a>
                              <a href={linkObj.twitter} target='_blank' rel='noopener noreferrer'>
                                <Twitter/>
                              </a>
                            </ListItem>
                        )
                      })
                    }
                  </ListWithTitle>
                </Grid>
              )
            )
          }
        </Grid>


      </Grid>

    </Container>
  )
}