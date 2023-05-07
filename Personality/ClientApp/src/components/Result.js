import {useParams} from "react-router-dom";
import {useEffect, useState} from "react";
import backend from "../helper/Backend";
import {Card, CardBody, CardHeader, Col, Row} from "reactstrap";
import Loading from "./Loading";

export default function Result() {
  let [session, setSession] = useState()
  let [personality, setPersonality] = useState()
  let {id} = useParams()
  
  useEffect(() => {
    backend.get("Sessions?sessionId=" + id)
      .then(r => setSession(r.data))
  }, [id])

  useEffect(() => {
    if (session) {
      backend.get("Personalities?score=" + session.score)
        .then(r => setPersonality(r.data))
    }
  }, [session])

  if (session) {
    return (
      <div className="m-5">
        <Row>
          <Col>
            <h2>Your result</h2>
            <div className="m-3">
              <h3>{personality?.title}</h3>
              <p className="m-2 h6">{personality?.description}</p>
            </div>
          </Col>
        </Row>
        <Row>
          <Col>
            <h2>Your answers</h2>
            <div className="m-3">
              {session.selections.map((element, index) => (
                <Card key={index} className="mb-3">
                  <CardHeader>
                    <p className="h5">{index + 1 + ". " + element.answer.question.text}</p>
                  </CardHeader>
                  <CardBody>
                    <p className="h6">{element.answer.text}</p>
                  </CardBody>
                </Card>
              ))}
            </div>
          </Col>
        </Row>
      </div>
    )
  } else {
    return <Loading />
  }
}