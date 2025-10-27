import PulseCard from './PulseCard'

interface PulseAnimeProps {
  times: number;
}

const PulseAnime = ({times} : PulseAnimeProps) => {
  return (Array.from({length: times}).map((_, index) => (<PulseCard key={index}/>)))
}

export default PulseAnime