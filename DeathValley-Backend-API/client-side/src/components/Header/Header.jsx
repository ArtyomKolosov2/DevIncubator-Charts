import React, { Component } from 'react';
import s from './Header.module.css';
import NavHeader from './NavHeader';

export default class Header extends Component {
    render() {
        return (
            <header className={s.header}>
                <NavHeader />
            </header>
        )
    }
}