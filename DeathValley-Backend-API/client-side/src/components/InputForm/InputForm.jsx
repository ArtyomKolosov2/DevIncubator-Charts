
import React, { Component } from 'react';
import { Form, Button, Col } from 'react-bootstrap';
import s from './InputForm.module.css';

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

    handleSubmit(e) {
        e.preventDefault();
        alert(`${this.state.a} ${this.state.b} ${this.state.c}`)
    }

    render() {
        return (
            <Form onSubmit={this.handleSubmit} className={s.form}>
                <Form.Group>
                    <Form.Group as={Col}>
                        <Form.Label>Function: </Form.Label>
                        <strong>y = </strong><Form.Control name="a" type="number" className={s.item} value={this.state.a} onChange={this.onChange} />
                        <strong>x^2 +</strong><Form.Control name="b" type="number" className={s.item} value={this.state.b} onChange={this.onChange} />
                        <strong>x + </strong><Form.Control name="c" type="number" className={s.item} value={this.state.c} onChange={this.onChange} />
                    </Form.Group>
                    <br /> <label>Step: </label><input name="step" type="number" value={this.state.step} onChange={this.onChange} />
                    <br /> <label>From: </label><input name="from" type="number" value={this.state.from} onChange={this.onChange} />
                    <p>to</p><label>To: </label><input name="to" type="number" value={this.state.to} onChange={this.onChange} />
                </Form.Group>
                <Button variant="primary" type="submit">
                    Отправить
                </Button>
            </Form>
        );
    }
}

export default InputForm;