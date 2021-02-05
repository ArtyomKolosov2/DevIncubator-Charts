import React, { Component } from 'react';
import { Navbar, Nav } from 'react-bootstrap';

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
                    </Nav>
                </Navbar>
            </div>);
    }
}