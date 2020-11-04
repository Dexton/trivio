import React, { Component } from 'react';
import { Container, Row } from 'reactstrap';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div>
        <Container className={"px-lg-5"} style={{height: "100vh"}}>
            {this.props.children}
        </Container>
      </div>
    );
  }
}
