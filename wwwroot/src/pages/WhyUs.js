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
    '& span.boldMe': {
      fontWeight: 800
    }
  },
  mainCopy: {
    '& span.orangeMe': {color: theme.palette.primary.main},
    '& span.boldMe': {fontWeight: 800}
  },
  copyImg: {

  }
}))

function BoldCopy({string}) {
  
  return (
    <span className='orangeMe'>
      {
        // check to see if any words in the string are wrapped in underscores
        string.match(/_\S+_/gi).length === 0 ? 
          // if no underscored words, treat everything as normal
          string
        :
          // split string by underscored words, also capturing underscored words, into array
          string.split(/(_\S+_)/).map((segment, index) => (
            segment[0] !== '_' ? 
              // return non-underscored strings as normal
              segment
            :
              // return underscored words in a span container
              (<span className='boldMe' key={index}>
                {segment.slice(1, -1)}
              </span>)
          ))
      }
    </span>
  )
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
          
            <Typography className={classes.mainCopy}>
              <BoldCopy string={whyUsData.bodyCopy.bold}/>
              &nbsp;
              {whyUsData.bodyCopy.body}
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