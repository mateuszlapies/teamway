import {useEffect, useState} from "react";
import backend from "../helper/Backend";
import {Button, Card, CardBody, CardHeader, Form, FormGroup, Input, Label} from "reactstrap";
import {useNavigate} from "react-router-dom";

export default function Test() {
  let navigate = useNavigate()
  let [questions, setQuestions] = useState([]);
  let [selections, setSelections] = useState([]);

  useEffect(() => {
    backend.get("Questions")
      .then(r => setQuestions(r.data))
      .catch(e => {
        console.log(e)
      })
  }, [])

  const onSubmit = (e) => {
    e.preventDefault()
    backend.put("Sessions", selections.map(element => element.answer))
      .then(r => navigate("/result?id=" + r.data.id))
  }

  const onChange = (e) => {
    setSelections(prevState => prevState.filter(element => element.question !== e.target.name))
    setSelections(prevState => [...prevState, { question: e.target.name, answer: e.target.value }])
  }

  return (
    <div className="m-5">
      <Form onSubmit={onSubmit}>
        {questions.map((question, index) => (
          <Card key={index} className="mb-3">
            <CardHeader>
              <p className="h4">{question.text}</p>
            </CardHeader>
            <CardBody>
              {question.answers.map((answer, answerIndex) => (
                <FormGroup check key={answerIndex}>
                  <Input key={answerIndex} type="radio" name={index} value={answer.id} onChange={onChange} />
                  <Label check>
                    <p className="h5">{answer.text}</p>
                  </Label>
                </FormGroup>
              ))}
            </CardBody>
          </Card>
        ))}
        <Button type="submit" size="lg" className="mt-3 float-end">Submit Your Answers</Button>
      </Form>
    </div>
  )
}