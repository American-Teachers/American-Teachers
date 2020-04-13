import React from 'react';

import Container from '@material-ui/core/Container';
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';

import { Logo } from '../components/Header';

import { makeStyles } from '@material-ui/core/styles';

import FacebookIcon from '@material-ui/icons/Facebook';
import TwitterIcon from '@material-ui/icons/Twitter';

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
];

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
                                <FacebookIcon/>
                              </a>
                              <a href={linkObj.twitter} target='_blank' rel='noopener noreferrer'>
                                <TwitterIcon/>
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