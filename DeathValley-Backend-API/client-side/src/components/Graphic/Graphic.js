import React, { Component } from 'react';
import JXGBoard from 'jsxgraph-react-js';

let logicJS = (brd) => {
  brd.suspendUpdate();
  var c = brd.create('curve', [[1,2,3,4], [1,4,5,6]]);
  brd.unsuspendUpdate();
}

class Example extends Component {
  render () {
    return (
        <JXGBoard
          logic={logicJS}
          boardAttributes={{ axis: true, boundingbox: [-12, 10, 12, -10] }}
          style={{
            border: "2px solid red"
          }}
        />
    )
  }
}

export default Example;