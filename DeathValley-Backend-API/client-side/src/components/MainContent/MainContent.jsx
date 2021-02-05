import React, { Component } from 'react';
import Graphic from '../Graphic/Graphic';
import InputForm from '../InputForm/InputForm';
import s from './MainContent.module.css';
import * as axios from 'axios';

export default class MainContent extends Component {
    constructor() {
        super();
        this.state = {
            loading: true,
            cordsX: [],
            cordsY: []
        };
    }
    async getGraphData(inputData) {
        let res = await axios.post('/api/Plot', inputData);
        console.log(res);
        console.log(res.data);
        if (res.status === 200) {
            this.setState({ loading: true });
            let x = [];
            let y = [];
            res.data.forEach(element => {
                x.push(element.x);
                y.push(element.y);
            });
            this.setState({ cordsX: x, cordsY: y, loading: false });
        }
    };
    static renderGraph(x, y) {
        return <Graphic x={x} y={y}></Graphic>
    }

    render() {
        let contents = this.state.loading
            ? <strong><em>Wait for data...</em></strong>
            : MainContent.renderGraph(this.state.cordsX, this.state.cordsY);
        return (
            <div className={`${s.content_wrapper} container`}>
                {contents}
                <InputForm callbackData={this.getGraphData.bind(this)}></InputForm>
            </div>);
    }
}