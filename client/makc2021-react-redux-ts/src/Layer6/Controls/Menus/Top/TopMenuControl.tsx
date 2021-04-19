// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import Nav from 'react-bootstrap/Nav';
import { NavLink, useLocation } from 'react-router-dom';

/**
 * Элемент управления "Верхнее меню".
 */
export function TopMenuControl() {
  const location = useLocation();

  return (
    <Nav className="justify-content-center" activeKey={location.pathname}>
      <Nav.Item>
        <Nav.Link href="/dummy-main/list">Список</Nav.Link>
      </Nav.Item>
      <Nav.Item>
        <NavLink to="/dummy-main/item" className="nav-link">
          Элемент
        </NavLink>
      </Nav.Item>
    </Nav>
  );
}
