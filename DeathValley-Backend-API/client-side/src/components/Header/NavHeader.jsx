import React, { Component } from 'react';
import { Navbar, Nav } from 'react-bootstrap';
import { NavLink } from 'react-router-dom';

export default class NavHeader extends Component {
    render() {
        return (
            <div>
                <br />
                <Navbar bg="primary" variant="dark">
                    <Navbar.Brand href="/">Death Valley</Navbar.Brand>
                    <Nav className="mr-auto">
                        <Nav.Link className='text-white' href="/swagger">
                            Swagger Docs
                        </Nav.Link>
                        <Nav.Link >
                            <NavLink className='text-white' to="/about">About</NavLink>
                        </Nav.Link>
                    </Nav>
                </Navbar>
            </div>);
    }
}