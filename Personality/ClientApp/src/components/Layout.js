import {Container} from 'reactstrap';
import Navigation from './Navigation';

export default function Layout(props) {
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
