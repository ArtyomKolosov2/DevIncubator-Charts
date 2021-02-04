
import React, { Component } from 'react';
import { Form, Button, Col } from 'react-bootstrap';
import s from './InputForm.module.css';
import * as axios from 'axios';

class InputForm extends Component {
    constructor(props) {
        super(props);
        this.state =
        {
            a: 1,
            b: 1,
            c: 1,
            step: 1,
            from: -10,
            to: 10
        };
        this.onChange = this.onChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    onChange(e) {
        this.setState({
            [e.target.name]: e.target.value
        });
    }

    async handleSubmit(e) {
        e.preventDefault();
        let data = {
            a: this.state.a,
            b: this.state.b,
            c: this.state.c,
            step: this.state.step,
            rangeFrom: this.state.from,
            rangeTo: this.state.to
        };

        let res = await axios.post('/api/Plot', data);
        console.log(res.data);

    }

    render() {
        return (
            <div className={s.form}>
                <Form onSubmit={this.handleSubmit} >
                    <Form.Group as={Col}>
                        <Form.Row className={s.form_group}>
                            <label>Function: </label><strong>y = <input name="a" type="number" value={this.state.a} onChange={this.onChange} /></strong>
                            <strong>x^2 + <input name="b" type="number" value={this.state.b} onChange={this.onChange} /></strong>
                            <strong>x + <input name="c" type="number" value={this.state.c} onChange={this.onChange} /></strong>
                        </Form.Row>
                        <Form.Row className={s.form_group}><label>Step: </label><input name="step" type="number" value={this.state.step} onChange={this.onChange} /></Form.Row>
                        <Form.Row className={s.form_group}>
                            <label>From: </label><input name="from" type="number" value={this.state.from} onChange={this.onChange} />
                            <label style={{ marginLeft: 10 }}>To: </label><input name="to" type="number" value={this.state.to} onChange={this.onChange} />
                        </Form.Row>
                    </Form.Group>
                    <Button className={s.form_btn} variant="primary" type="submit">
                        Отправить
                    </Button>
                </Form>
            </div>
        );
    }
}

export default InputForm;