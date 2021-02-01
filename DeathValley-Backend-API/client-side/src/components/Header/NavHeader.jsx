import React, { Component } from 'react';
import { Navbar, Nav } from 'react-bootstrap';

export default class NavHeader extends Component {
    render() {
        return (
            <div>
                <br />
                <Navbar bg="primary" variant="dark">
                    <Navbar.Brand href="#home">Navbar</Navbar.Brand>
                    <Nav className="mr-auto">
                        <Nav.Link href="#home">Home</Nav.Link>
                        <Nav.Link href="#features">Features</Nav.Link>
                        <Nav.Link href="#pricing">Pricing</Nav.Link>
                    </Nav>
                </Navbar>
            </div>);
    }
}