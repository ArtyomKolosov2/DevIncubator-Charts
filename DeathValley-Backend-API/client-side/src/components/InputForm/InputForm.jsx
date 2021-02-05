import React, { Component } from 'react';
import { Form, Button, Col } from 'react-bootstrap';
import s from './InputForm.module.css';
import ValidationErrorMessages from '../ValidationErrorMessages/ValidationErrorMessages.jsx'

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
            to: 10,
            formErrors: {
                step: '',
                range: '',
                a: '',
                b: '',
                c: ''
            },
            stepValid: true,
            rangeValid: true,
            isValidConstA: true,
            isValidConstB: true,
            isValidConstC: true,
            formValid: true
        };
        this.onChange = this.onChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    validateField(fieldName, value) {
        let fieldValidationErrors = this.state.formErrors;
        let stepValid = this.state.stepValid;
        let rangeValid = this.state.rangeValid;
        let isValidConstA = this.state.a;
        let isValidConstB = this.state.b;
        let isValidConstC = this.state.c;
        switch (fieldName) {
            case 'step':
                stepValid = value > 0 && value.length > 0;
                fieldValidationErrors.step = stepValid ? '' : ' invalid';
                break;
            case 'from':
                rangeValid = Number(this.state.from) < Number(this.state.to) && value.length > 0;
                fieldValidationErrors.range = rangeValid ? '' : ' is invalid';
                break;
            case 'to':
                rangeValid = Number(this.state.to) >= Number(this.state.from) && value.length > 0;
                fieldValidationErrors.range = rangeValid ? '' : ' is invalid';
                break;
            case 'a':
                isValidConstA = !(value == null || value === undefined || value.length === 0);
                fieldValidationErrors.a = isValidConstA ? '' : ' constant is required';
                break;
            case 'b':
                isValidConstB = !(value == null || value === undefined || value.length === 0);
                fieldValidationErrors.b = isValidConstB ? '' : ' constant is required';
                break;
            case 'c':
                isValidConstC = !(value == null || value === undefined || value.length === 0);
                fieldValidationErrors.c = isValidConstC ? '' : ' constant is are required';
                break;
            default:
                break;
        }
        this.setState({
            formErrors: fieldValidationErrors,
            stepValid: stepValid,
            rangeValid: rangeValid,
            isValidConstA: isValidConstA,
            isValidConstB: isValidConstB,
            isValidConstC: isValidConstC,
        }, this.validateForm);

    }
    validateForm() {
        this.setState({
            formValid: this.state.stepValid &&
                this.state.rangeValid &&
                this.state.isValidConstA &&
                this.state.isValidConstB &&
                this.state.isValidConstC
        });
    }

    onChange(e) {
        this.setState({
            [e.target.name]: e.target.value,
        }, () => { this.validateField(e.target.name, e.target.value) });
    }

    handleSubmit(e) {
        e.preventDefault();
        let data = {
            a: this.state.a,
            b: this.state.b,
            c: this.state.c,
            step: this.state.step,
            rangeFrom: this.state.from,
            rangeTo: this.state.to
        };
        this.props.callbackData(data);
    }

    render() {
        return (
            <div>
                <Form className={s.form} onSubmit={this.handleSubmit} >
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
                    <Button className={s.form_btn} disabled={!this.state.formValid} variant="primary" type="submit">
                        Отправить
                    </Button>
                </Form>
                <div><ValidationErrorMessages formErrors={this.state.formErrors} /></div>
            </div >
        );
    }
}

export default InputForm;