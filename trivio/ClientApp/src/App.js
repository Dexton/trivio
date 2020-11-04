import React, { Component } from 'react';
import { Row } from 'reactstrap';
import { Layout } from './components/Layout';
import { Search } from './components/Search';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Row className={"py-lg-5 justify-content-center"}>
          <h1 className="display-1">Title?</h1>
        </Row>
        <Row className={"py-lg-5"}>
          <Search />
        </Row>
      </Layout>
    );
  }
}
