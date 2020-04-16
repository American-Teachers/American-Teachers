import React from 'react';

import { FeatureCollection } from './Landing.js';

import Container from '@material-ui/core/Container';
import Typography from '@material-ui/core/Typography';
import Divider from '@material-ui/core/Divider';
import Grid from '@material-ui/core/Grid';

import Layout from '../components/Layout';
import { makeStyles } from '@material-ui/core/styles';

import bannerImg from '../../public/whyus-banner.jpg';
import gettingImg from '../../public/whyus-gettingbetter.jpg';

const whyUsData = {
  topQuote: {
    body: '"Education is the passport to the future, for tomorrow belongs to those who prepare for it today."',
    source: '- Malcolm X'
  },
  bodyCopy: {
    // surround bolded words with underscore
    bold: 'We believe _everyone_ should have access to an _uncompromised_ education online and offline.',
    body: 'We are a team of teachers, students, engineers and designers that are passionate about continuing a full education to students everywhere now and for the future. Our hope is that this platform brings positive impact and connects humans everywhere.'
  }
}

const useStyles = makeStyles((theme) => ({
  root: {
    '& hr': {
      width: theme.spacing(13),
      height: '2px',
      margin: '0 auto',
      backgroundColor: theme.palette.primary.main
    }
  },
  quoteContainer: {
    maxWidth: theme.spacing(135.75),
    // minHeight: theme.spacing(16.75),
    textAlign: 'center',
    padding: `0 ${theme.spacing(5)}px`,
    marginTop: theme.spacing(9),
    marginBottom: theme.spacing(6.5),

    '& h2': {
      fontFamily: 'Merriweather',
      fontSize: '32px',
      lineHeight: '40px',
      letterSpacing: '1.5px'
    },

    '& h3': {
      fontSize: '18px',
      marginTop: theme.spacing(2),
      color: theme.palette.primary.main
    }
  },

  imgBanner: {
    backgroundImage: `url("${bannerImg}")`,
    width: '100%',
    height: theme.spacing(52),
    margin: `0 auto ${theme.spacing(8)}px`
  },

  mainSection: {
    position: 'static',
    backgroundColor: 'pink',
    margin: `${theme.spacing(8)}px 0 0`,
    padding: `${theme.spacing(3)}px ${theme.spacing(9.5)}px`
  },
  mainCopyBold: {
    '& span': {
      fontWeight: 'bold'
    }
  },
  mainCopyBody: {

  },
  copyImg: {

  }
}))

function BoldCopy({string, classes}) {
  
  // check to see if any words in the string are wrapped in underscores
  if (string.match(/_\S+_/gi).length > 0) {
    
    // split string by underscored words, also capturing underscored words, into array
    const separatedString = string.split(/(_\S+_)/);

    return (
      <Typography className={classes.mainCopyBold}>
        {
          separatedString.map(string => (
            string[0]!=='_' ?
              string
            :
              (<span>
                {string.slice(1, -1)}
              </span>)
          ))
        }
      </Typography>
    )

  // if no underscored words, treat everything as normal
  } else {
    return (
      <Typography className={classes.mainCopyBold}>
        {string}
      </Typography>  
    )
  }

  // return (
  //   <Typography className={classes.mainCopyBold}>
  //     {
  //       string.match(/_\S+_/gi).length === 0 ? 
  //         string
  //       :
  //         string.split(/(_\S+_)/).map(segment => (
  //           segment[0] !== '_' ? 
  //             segment
  //           :
  //             (<span>
  //               {segment.slice(1, -1)}
  //             </span>)
  //         ))
  //     }
  //   </Typography>
  // )
}

export default function WhyUs() {
  const classes = useStyles();

  return (
    <Layout>
      <Container className={classes.root} maxWidth='xl' disableGutters>
        <Container className={classes.quoteContainer}>
          <Typography variant='h2'>
            {whyUsData.topQuote.body}
          </Typography>

          <Typography variant='h3'>
            {whyUsData.topQuote.source}
          </Typography>
        </Container>

        <div className={classes.imgBanner}/>

        <Divider/>
        
        <Grid container className={classes.mainSection} spacing={4}>
          <Grid item sm={6}>
            <BoldCopy string={whyUsData.bodyCopy.bold} classes={classes}/>

            <Typography>

            </Typography>
          </Grid>

          <Grid item sm={6}>
            <div className={classes.copyImg}/>
          </Grid>
        </Grid>

        <FeatureCollection/>
      </Container>
    </Layout>
  )
}