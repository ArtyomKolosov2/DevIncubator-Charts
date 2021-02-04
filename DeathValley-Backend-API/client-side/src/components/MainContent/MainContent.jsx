import React, { Component } from 'react';
import Example from '../Graphic/Graphic';
import InputForm from '../InputForm/InputForm';
import ValidationErrorMessages from '../ValidationErrorMessages/ValidationErrorMessages';
import s from './MainContent.module.css';


export default class MainContent extends Component {
    render() {
        return (
            <div className={`${s.content_wrapper} container`}>
                <Example></Example>
                <InputForm></InputForm>
                <ValidationErrorMessages></ValidationErrorMessages>
            </div>);
    }
}