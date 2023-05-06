import { useState } from 'react';
import {Collapse, Nav, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink} from 'reactstrap';

export default function Navigation()
{
  let [collapsed, setCollapsed] = useState(true);

  const toggle = () => {
    setCollapsed(!collapsed)
  }

  return (
    <Navbar container light expand>
      <NavbarBrand href="/">Personality Test</NavbarBrand>
      <NavbarToggler onClick={toggle} />
      <Collapse isOpen={!collapsed} navbar>
        <Nav navbar>
          <NavItem>
            <NavLink href="/">Home</NavLink>
          </NavItem>
        </Nav>
      </Collapse>
    </Navbar>
  );
}
