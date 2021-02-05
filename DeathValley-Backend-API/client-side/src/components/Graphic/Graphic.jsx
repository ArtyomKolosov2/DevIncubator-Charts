import React, { Component } from 'react';
import JXGBoard from 'jsxgraph-react-js';
import s from './Graphic.module.css';

class Graphic extends Component {

  logicJS = (brd) => {
    brd.suspendUpdate();
    brd.create('curve', [this.props.x, this.props.y]);
    brd.unsuspendUpdate();
  }

  render() {
    return (
      <JXGBoard className={s.graphic}
        logic={this.logicJS}
        boardAttributes={{ axis: true, boundingbox: [-80, 80, 80, -80] }}
        style={{
          border: "2px solid red"
        }}
      />
    )
  }
}

export default Graphic;