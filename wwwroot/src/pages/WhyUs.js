import React from 'react';

import { FeatureCollection } from './Landing.js';

import Layout from '../components/Layout';
import { makeStyles } from '@material-ui/core/styles';

import bannerImg from '../../public/whyus-banner.jpg';
import gettingImg from '../../public/whyus-gettingbetter.jpg';

const whyUsData = {
  topQuote: {
    body: '"Education is the passport to the future, for tomorrow belongs to those who prepare for it today."',
    source: '- Malcom X'
  },
  bodyCopy: {
    boldParseInput: 'We believe _everyone_ should have access to an _uncompromised_ education online and offline.',
    body: 'We are a team of teachers, students, engineers and designers that are passionate about continuing a full education to students everywhere now and for the future. Our hope is that this platform brings positive impact and connects humans everywhere.'
  }
}

const useStyles = makeStyles((theme) => ({
  root: {}
}))

export default function WhyUs() {
  return (
    <Layout>
      <div>
        <h3>Why Us</h3>
      </div>
      <FeatureCollection/>
    </Layout>
  )
}