import { ReactElement, JSXElementConstructor, ReactFragment, ReactPortal } from 'react';
import {Container} from 'reactstrap';
import Navigation from './Navigation';

export default function Layout(props: { children: string | number | boolean | ReactElement<any, string | JSXElementConstructor<any>> | ReactFragment | ReactPortal | null | undefined; }) {
  return (
    <div className="box fill-height">
      <div className="header">
        <Navigation />
      </div>
      <div className="content">
        <Container className="fill-height">
          {props.children}
        </Container>
      </div>
    </div>
  );
}
